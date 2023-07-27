namespace Make_standard_structure_for_returning_JSON.Error
{
    public static class ApiResponseHelper
    {
        public static ApiResponse<T> CreateSuccessResponse<T>(T data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSuccess = true
            };
        }

        public static ApiResponse<object> CreateErrorResponse(string errorMessage)
        {
            return new ApiResponse<object>
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }
    }
}