using System;
using System.Reflection;
using FullDemo.Models.POCO;

namespace FullDemo.Extensions
{
    /// <summary>
    /// Converts a Data Transfer Object (DTO) to a Plain Old CLR Object (POCO).
    /// </summary>
    public static class DTOtoPOCOExtension
    {
         public static T Convert<T>(this object dto)
        {
            // Get the type of POCO
            Type pocoType = typeof(T);
            
            // Create instance of POCO Type
            T pocoInstance = (T)Activator.CreateInstance(pocoType);

            // Get properties of DTO
            PropertyInfo[] dtoProperties = dto.GetType().GetProperties();

            // Get properties of POCO
            PropertyInfo[] pocoProperties = pocoType.GetProperties();

            // Iterate through each property of DTO and find corresponding POCO properties
            foreach (PropertyInfo dtoProperty in dtoProperties)
            {
                PropertyInfo pocoProperty = Array.Find(pocoProperties, p => p.Name == dtoProperty.Name);

                // check whether matched property is found and dto property is not null
                if (dtoProperty != null && dtoProperty.PropertyType == pocoProperty.PropertyType)
                {
                    object value = dtoProperty.GetValue(dto);
                    pocoProperty.SetValue(pocoInstance, value);
                }
            }

            // return the converted POCO object
            return pocoInstance;
        }
    }
}
