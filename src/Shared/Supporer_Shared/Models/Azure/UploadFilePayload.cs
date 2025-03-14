using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporer_Shared.Models.Azure
{
    public record UploadFilePayload(string containerName, string fileName, string fileContent);
}
