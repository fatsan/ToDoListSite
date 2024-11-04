
using Core.Exceptions;
using ToDoListSite.Models.Entities;

namespace ToDoListSite.Service.Rules;

public class CategoryBusinessRules
{
    public virtual void CategoryIsNullCheck(Category category)
    {
        if (category is null)
        {
            throw new NotFoundException("İlgili ToDo bulunamadı.");
        }
    }
}
