using DilkePass.Domain.Common;

namespace DilkePass.Domain.Entities
{
    public class TouristType : Entity<int>
    {
        public string TouristTypeCode { get; private set; } = string.Empty;
        public string TypeName { get; private set; } = string.Empty;
        public int MinAge { get; private set; } = 0;
        public int MaxAge { get; private set; } = 0;
        public string? Description { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }



        protected TouristType()
        {

        }

        // Not needed as of now
        public static TouristType CreateTouristType(string typeCode, string typeName, int minAge, int maxAge, string? description)
        {
            if (string.IsNullOrWhiteSpace(typeCode))
                throw new ArgumentNullException("Type Code can not be blank");
            if (string.IsNullOrWhiteSpace(typeName))
                throw new ArgumentNullException("Type Name is needed");
            if (minAge < 0 && maxAge < 0 && minAge > maxAge)
                throw new ArgumentOutOfRangeException("Min Age can not be more than MaxAge");

            var tourType = new TouristType()
            {
                TouristTypeCode = typeCode,
                TypeName = typeName,
                MinAge = minAge,
                MaxAge = maxAge,
                Description = description,
                IsActive =true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow

                  

            };

            return tourType;


        }

    }
}
