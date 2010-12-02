using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ThisApplication
{
    // http://groups.google.com/group/structuremap-users/browse_thread/thread/d02aee1a8497764b/890dd4fde6af0c5d?hl=en&lnk=gst&q=WCF+#890dd4fde6af0c5d

    public abstract class DisposableClientBase<T> : ClientBase<T> where T : class
    {
        private bool _disposed;

        protected DisposableClientBase()
        {
        }

        //protected DisposableClientBase(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) 
        //{ 
        //} 

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(!_disposed && disposing && ChannelFactory != null)
            {
                if(ChannelFactory.State == CommunicationState.Faulted)
                    ChannelFactory.Abort();
                else
                    ChannelFactory.Close();
                ((IDisposable)ChannelFactory).Dispose();
            }
            _disposed = true;
        }
    }
}
