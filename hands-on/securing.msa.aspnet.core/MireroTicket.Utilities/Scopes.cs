namespace MireroTicket.Utilities
{
    public static class Scopes
    {
        public const string OpenId = "openid";
        public const string Profile = "profile";
        
        public static class EventCatalog
        {
            public const string Read = "mireroticket.scope.event-catalog.read";
            public const string Write = "mireroticket.scope.event-catalog.write";
        }

        public static class Discount
        {
            public const string All = "mireroticket.scope.discount.all";
        }

        public static class ShoppingBasket
        {
            public const string All = "mireroticket.scope.shopping-basket.all";
        }
    }

    public static class ClientIds
    {
        public const string EventCatalogReader = "mireroticket.client.event-catalog.reader";
        public const string MvcClient = "mireroticket.client.code-only-ui";
        public const string GeneralClient = "mireroticket.client.ui";
        public const string ShoppingBasketToDiscount = "mireroticket.client.shopping-basket.discount.service";
    }

    public static class Audiences
    {
        public const string EventCatalog = "mireroticket.aud.event-catalog";
        public const string ShoppingBasket = "mireroticket.aud.shopping-basket";
        public const string Discount = "mireroticket.aud.discount";
    }
}