using Core.Exceptions;
using ToDoListSite.Models.Entities;

namespace ToDoListSite.Service.Rules;

public class ToDoBusinessRules
{

    public virtual void ToDoIsNullCheck(ToDo toDo)
    {
        if (toDo is null)
        {
            throw new NotFoundException("İlgili ToDo bulunamadı.");
        }
    }


}
