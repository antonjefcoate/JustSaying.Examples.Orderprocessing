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
    public partial class Form1 : Form, IHandler<OrderValidatedOk>
    {
        private readonly IMessagePublisher _publisher;
        private Guid? _currentOrderId;

        public Form1(IMessagePublisher publisher)
        {
            _publisher = publisher;
            InitializeComponent();
        }

        public bool Handle(OrderValidatedOk message)
        {
            _currentOrderId = message.OrderId;

            DoUI(() => { NameBox.Text = message.CustomerName; });
            DoUI(() => { IdBox.Text = message.OrderId.ToString(); });
            DoUI(() => { OrderItems.Text = message.OrderContents; });

            return false;
        }

        #region Ignore...thread safe nonsense...
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

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            _publisher.Publish(new OrderAccepted(_currentOrderId.Value));
            ClearForm();
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            _publisher.Publish(new OrderRejected(_currentOrderId.Value, "We just don't care"));
            ClearForm();
        }

        private void ClearForm()
        {
            NameBox.Clear();
            IdBox.Clear();
            OrderItems.Clear();
        }
    }
}
