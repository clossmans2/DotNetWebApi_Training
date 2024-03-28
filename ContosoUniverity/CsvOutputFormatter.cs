using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;

namespace ContosoUniversity
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(StudentDto).IsAssignableFrom(type) || typeof(IEnumerable<StudentDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<StudentDto>)
            {
                foreach (var student in (IEnumerable<StudentDto>)context.Object)
                {
                    FormatCsv(buffer, student);
                }
            }
            else
            {
                FormatCsv(buffer, (StudentDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }

        private static void FormatCsv(StringBuilder buffer, StudentDto student)
        {
            buffer.AppendLine($"{student.Id},\"{student.FullName}\",\"{student.Email}\"");
        }
    }
}
