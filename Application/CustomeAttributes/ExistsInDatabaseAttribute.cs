using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomeAttributes
{
    public class ExistsInDatabaseAttribute<TEntity> : ValidationAttribute where TEntity : class  
    {        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"شناسه نمی‌تواند خالی باشد.");
            }

            var dbContext = validationContext.GetService(typeof(IDataBaseContext)) as IDataBaseContext;
            if (dbContext == null)
            {
                throw new InvalidOperationException("DbContext مورد نیاز است.");
            }
            
            var entity = dbContext.Set<TEntity>().Find(value);

            if (entity == null)
            {
                return new ValidationResult($"id {value} is not find");
            }

            return ValidationResult.Success;
        }
    }
}
