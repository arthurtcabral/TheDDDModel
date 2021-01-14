using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Notifications
{
    /// <summary>
    /// Esta classe é responsável por verificar se as propriedades estão preenchidas
    /// e por setar uma mesagem de retorno ao usuário.
    /// </summary>
    public class Notification
    {
        public Notification() { }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notification> NotificationList { get; set; }

        public bool ValidateStringProperty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                NotificationList.Add(
                    new Notification
                    {
                        PropertyName = propertyName,
                        Message = "Campo obrigatório"
                    }
                );
                return false;
            }
            return true;
        }

        public bool ValidateIntProperty(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                NotificationList.Add(
                    new Notification
                    {
                        PropertyName = propertyName,
                        Message = "Campo obrigatório"
                    }
                );
                return false;
            }
            return true;
        }

    }
}
