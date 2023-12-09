namespace CarStore.Models
{
    // This class represents the model for handling errors in the application.
    public class ErrorViewModel
    {
        // Property to store the unique identifier for the error request.
        public string? RequestId { get; set; }

        // A read-only property that indicates whether to show the error request ID.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
