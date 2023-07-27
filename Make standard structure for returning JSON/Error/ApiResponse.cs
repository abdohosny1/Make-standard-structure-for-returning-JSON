namespace Make_standard_structure_for_returning_JSON.Error
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; } //= null!;
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}