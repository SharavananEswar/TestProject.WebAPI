namespace ZipPay.WebApi.DTOs
{
    public class UsersListResponse
    {
        public UserResponse[] Items { get; set; }
        public long TotalCount { get; set; }
    }
}