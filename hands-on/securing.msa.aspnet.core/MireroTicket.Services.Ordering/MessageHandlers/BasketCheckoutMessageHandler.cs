using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MireroTicket.Services.Common;
using MireroTicket.Services.Ordering.DbContexts;
using MireroTicket.Services.Ordering.Entities;
using MireroTicket.Services.Ordering.Messages;

namespace MireroTicket.Services.Ordering.MessageHandlers
{
    public class BasketCheckoutMessageHandler : AsyncRequestHandler<BasketCheckoutMessage>
    {
        private readonly DbContextOptions<OrderingDbContext> _dbContextOptions;

        public BasketCheckoutMessageHandler(DbContextOptions<OrderingDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }
        
        protected override async Task Handle(BasketCheckoutMessage request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid().ToDbString(),
                Paid = false,
                Total = request.BasketTotal,
                PlacedTime = DateTime.Now.ToDbDateTimeString(),
                UserId = request.UserId
            };
            await using var dbContext = new OrderingDbContext(_dbContextOptions);
            await dbContext.Orders.AddAsync(order, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}