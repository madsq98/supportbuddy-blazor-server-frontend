namespace SB.BlazorServer.Data.Attachment;

public class AttachmentService
{
    private HttpClient _http;

    public AttachmentService(HttpClient httpClient)
    {
        _http = httpClient;
    }

    public async Task<Models.Attachment> UploadFileAsync(MultipartFormDataContent data)
    {
        try
        {
            var response = await _http.PostAsync("", data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Models.Attachment>();
            }
            
            return null;
        }
        catch
        {
            return null;
        }
    }
}