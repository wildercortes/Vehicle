using Autofac.Features.Indexed;
using MediatR;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Core.Data.Helpers;

namespace Vehicle.Core.Data.EF.Behaviors
{
    public class TransactionalBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly DataContext dataContext;
        //private readonly ILogger logger;

        public TransactionalBehavior(DataContext dataContext, IIndex<string, ILogger> loggerIndex)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            //this.logger = loggerIndex[LoggerConstants.apiLoggerName];
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!typeof(IRequest).IsAssignableFrom(request.GetType()))
                return await next();

            var response = await next();
            try
            {
                await dataContext.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                //logger.Error("Error al guardar: " + Ex.InnerException);
                throw;
            }
            return response;
        }
    }
}
