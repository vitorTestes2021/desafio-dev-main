using System;
using System.Threading.Tasks;
using api.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace api.Validators
{
    public class FormValidator
    {
        public async Task<MultipartSection> Validate(HttpRequest Request)
        {
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                throw new Exception("Not a multipart request");
            }

            var boundary = MultipartRequestHelper.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType));
            var reader = new MultipartReader(boundary, Request.Body);

            var section = await reader.ReadNextSectionAsync();

            if (section == null)
            {
                throw new Exception("No sections in multipart defined");
            }

            if (!ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition))
            {
                throw new Exception("No content disposition in multipart defined");
            }

            var fileName = contentDisposition.FileNameStar.ToString();
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = contentDisposition.FileName.ToString();
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("No filename defined.");
            }

            return section;
        }
    }
}