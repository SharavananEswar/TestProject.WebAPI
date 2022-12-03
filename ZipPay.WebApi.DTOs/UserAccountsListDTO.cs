namespace ZipPay.WebApi.DTOs
{
    public class UsersAccountsListResponse
    {
        public UserAccountResponse[] Items { get; set; }
        public long TotalCount { get; set; }
    }
}