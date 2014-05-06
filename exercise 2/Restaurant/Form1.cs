using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustSaying.Messaging;
using JustSaying.Messaging.MessageHandling;
using Messages.Events;

namespace Restaurant
{
    public partial class Form1 : Form
    {
        private readonly IMessagePublisher _publisher;
        private Guid? _currentOrderId;

        public Form1(IMessagePublisher publisher)
        {
            _publisher = publisher;
            InitializeComponent();
            ClearForm();
        }

        public bool ShowOrder(OrderValidatedOk message)
        {
            // If we're still deciding on an order, wait till later to grab the message.
            if (_currentOrderId.HasValue)
                return false;

            _currentOrderId = message.OrderId;

            DoUI(() => { NameBox.Text = message.CustomerName; });
            DoUI(() => { IdBox.Text = message.OrderId.ToString(); });
            DoUI(() => { OrderItems.Text = message.OrderContents; });

            DoUI(() => { AcceptButton.Enabled = true; });
            DoUI(() => { RejectButton.Enabled = true; });

            return true;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            //Todo: publish order accepted
            ClearForm();
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            //todo: publish order rejected
            ClearForm();
        }

        private void ClearForm()
        {
            _currentOrderId = null;

            NameBox.Clear();
            IdBox.Clear();
            OrderItems.Clear();

            AcceptButton.Enabled = false;
            RejectButton.Enabled = false;
        }



        #region Ignore...thread safe UI nonsense...
        private delegate void InvokeAction();
        private void DoUI(InvokeAction call)
        {
            if (IsDisposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                try
                {
                    Invoke(call);
                }
                catch (InvalidOperationException)
                {
                    // Handle error
                }
            }
            else
            {
                call();
            }
        }
        #endregion
    }
}
