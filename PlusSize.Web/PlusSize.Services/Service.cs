using PlusSize.Data;

namespace PlusSize.Services
{
    public abstract class Service
    {
        private PlusSizeContext context;
        protected Service()
        {
            this.context = new PlusSizeContext();
        }
        protected PlusSizeContext Context => this.context;
    }
}
