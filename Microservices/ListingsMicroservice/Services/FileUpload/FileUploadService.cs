﻿using RealEstate.Data.Repository;
using RealEstate.Models.Entities.Files;

<<<<<<< Updated upstream
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/FileUpload/FileUploadService.cs
namespace RealEstate.Microservices.FileUpload
=======
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/Utils/FileUpload/FileUploadService.cs
namespace RealEstate.Microservices.Utils.FileUpload
>>>>>>> Stashed changes
=======
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/FileUpload/FileUploadService.cs
namespace RealEstate.Microservices.FileUpload
=======
namespace UtilitiesMicroservice.Services.FileUpload
>>>>>>> Stashed changes:Microservices/UtilitiesMicroservice/Services/FileUpload/FileUploadService.cs
<<<<<<< Updated upstream
>>>>>>> Stashed changes:Microservices/UtilitiesMicroservice/Services/FileUpload/FileUploadService.cs
=======
>>>>>>> Stashed changes:Microservices/ListingsMicroservice/Services/FileUpload/FileUploadService.cs
>>>>>>> Stashed changes
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IApplicationDbRepository repo;

        public FileUploadService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        // UPLOAD
        public async Task<bool> UploadFile(IFormFile file, string fileType)
        {
            bool result = false;

            if (file == null || file.Length == 0)
            {
                return result;
            }

            // Validate file type
            if (fileType != "image" && fileType != "video")
            {
                return result;
            }

            // Read file into a byte array
            byte[] fileData;
            using (var stream = file.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    fileData = memoryStream.ToArray();
                }
            }

            // Create a new File entity and save to the database
            var fileEntity = new FileEntity
            {
                FileName = file.FileName,
                FileType = fileType,
                Data = fileData
            };
            await repo.AddAsync(fileEntity);
            await repo.SaveChangesAsync();

            result = true;
            return result;
        }

        // HARD DELETE
        public async Task<bool> DeleteFile(int id)
        {
            bool result = false;
            var file = await repo.GetByIdAsync<FileEntity>(id);

            if (file != null)
            {
                repo.Delete(file);
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // SOFT DELETE
        public async Task<bool> SoftDeleteFile(int id)
        {
            bool result = false;
            var file = await repo.GetByIdAsync<FileEntity>(id);

            if (file != null)
            {
                file.IsDeleted = true;
                file.DeletedOn = DateTime.UtcNow;
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // UPDATE FILE
        public async Task<bool> UpdateFile(int id, IFormFile file, string fileType)
        {
            bool result = false;
            var existingFile = await repo.GetByIdAsync<FileEntity>(id);

            if (existingFile != null)
            {
                // Validate file type
                if (fileType != "image" && fileType != "video")
                {
                    return result;
                }

                // Read file into a byte array
                byte[] fileData;
                using (var stream = file.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        fileData = memoryStream.ToArray();
                    }
                }

                // Update the file's metadata and data
                existingFile.FileName = file.FileName;
                existingFile.FileType = fileType;
                existingFile.Data = fileData;
                await repo.SaveChangesAsync();

                result = true;
            }

            return result;
        }
    }
}
