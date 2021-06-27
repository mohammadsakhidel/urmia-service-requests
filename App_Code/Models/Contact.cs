using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class Contact
    {
        public static string GetValue(int contactId, string fieldIdentifier)
        {
            try
            {
                ContacsRepository cr = new ContacsRepository();
                Contact contact = cr.GetContact(contactId);
                return contact.FieldValues.Where(fv => fv.Field.Identifier == fieldIdentifier).Select(fv => (fv.Value != null ? fv.Value : "")).First();
            }
            catch
            {
                return "";
            }
        }

        public static string GetValue(int contactId, int fieldId)
        {
            try
            {
                ContacsRepository cr = new ContacsRepository();
                Contact contact = cr.GetContact(contactId);
                return contact.FieldValues.Where(fv => fv.Field.ID == fieldId).Select(fv => (fv.Value != null ? fv.Value : "")).First();
            }
            catch
            {
                return "";
            }
        }
    }
}