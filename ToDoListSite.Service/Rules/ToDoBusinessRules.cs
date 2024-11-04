using Core.Exceptions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
