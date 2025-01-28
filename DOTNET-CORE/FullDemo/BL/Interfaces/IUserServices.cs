using System;
using FullDemo.Models.ENUM;
using FullDemo.Models.POCO;
using FullDemo.Models;
using static Google.Protobuf.Reflection.FeatureSet.Types;

namespace FullDemo.BL.Interfaces
{
    public interface IUserServices<TDTO> where TDTO : class
    {
        /// <summary>
        /// Gets or sets the type of operation (e.g., Add, Edit, Delete) to be performed.
        /// </summary>
        public EnmType Type { get; set; }

        /// <summary>
        /// Prepares the data before saving it.
        /// This method is invoked to handle any necessary preparation steps (e.g., mapping or transformation) before saving.
        /// </summary>
        /// <param name="objDTO">The data object (DTO or POCO) to be processed.</param>
        void PreSave(TDTO objDTO);

        /// <summary>
        /// Validates the data before performing the save operation.
        /// This method checks if the data is in a valid state for saving, ensuring that no errors occur during the save.
        /// </summary>
        /// <returns>A response indicating whether the validation was successful or if errors were found.</returns>
        Response Validation();

        /// <summary>
        /// Saves the data after validation and preparation.
        /// This method handles the actual saving process, such as adding, updating, or deleting data in the database.
        /// </summary>
        /// <returns>A response indicating whether the save operation was successful or if an error occurred.</returns>
        Response Save();

        /// <summary>
        /// Prepares an object for deletion based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the object to delete.</param>
        /// <returns>The prepared object.</returns>
        ITH01 PreDelete(int id);

        /// <summary>
        /// Validates an object before deletion.
        /// </summary>
        /// <param name="objPOCO">The object to validate.</param>
        /// <returns>A <see cref="Response"/> indicating the validation result.</returns>
        Response ValidationOnDelete(ITH01 objPOCO);

        /// <summary>
        /// Deletes an object from the database based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the object to delete.</param>
        /// <returns>The number of rows affected by the deletion.</returns> 
        Response Delete(int id);
    }
}