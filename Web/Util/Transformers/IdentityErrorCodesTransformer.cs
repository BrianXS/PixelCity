namespace Web.Util.Transformers
{
    public static class IdentityErrorCodesTransformer
    {
        public static string Init(string code)
        {
            switch (code)
            {
              case "DuplicateEmail":
                return "Este correo ya ha sido usado con otra cuenta";
                //error for duplicate emails
              
              case "DuplicateUserName":
                return "El nombre de usuario ya existe";
                //error for duplicate usernames
              
              case "ExternalLoginExists":
                return "A user with that external login already exists";
                //Error when a login already linked
              
              case "InvalidEmail":
                return "El correo es invalido";
                //invalid email
              
              case "InvalidToken":
                return "Invalid token";
                //Error when a token is not recognized
              
              case "InvalidUserName":
                return "El nombre de usuario es invalido, solo puede contener letras y numeros";
                //usernames can only contain letters or digits
              
              case "LockoutNotEnabled":
                return "Esta cuenta de usuario se encuentra bloqueada";
                //error when lockout is not enabled
              
              case "NoTokenProvider":
                return "No IUserTokenProvider is registered";
                //Error when there is no IUserTokenProvider
              
              case "NoTwoFactorProvider":
                return "No IUserTwoFactorProvider for '{0}' is registered";
                //Error when there is no provider found
              
              case "PasswordMismatch":
                return "Contraseña o Nombre de Usuario incorrecto";
                //Error when a password doesn't match
              
              case "PasswordRequireDigit":
                return "La contraseña debe contener al menos un digito ('0'-'9')";
                //Error when passwords do not have a digit
              
              case "PasswordRequireLower":
                return "La contraseña debe contener al menos una minuscula ('a'-'z')";
                //Error when passwords do not have a lowercase letter
              
              case "PasswordRequireNonLetterOrDigit":
                return "La contraseña debe contener al menos un simbolo";
                //Error when password does not have enough letter or digit characters
              
              case "PasswordRequireUpper":
                return "La contraseña debe contener al menos una mayuscula ('A'-'Z')";
                //Error when passwords do not have an uppercase letter
              
              case "PasswordTooShort":
                return "La clave es muy corta y debe tener minimo 6 caracteres";
                //Error message for passwords that are too short
              
              case "PropertyTooShort":
                return "El nombre de usuario no puede estar vacio";
                //error for empty or null usernames
              
              case "RoleNotFound":
                return "Role {0} does not exist";
                //error when a role does not exist
              
              case "StoreNotIQueryableRoleStore":
                return "Store does not implement IQueryableRoleStore&lt;TRole&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIQueryableUserStore":
                return "Store does not implement IQueryableUserStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserClaimStore":
                return "Store does not implement IUserClaimStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserConfirmationStore":
                return "Store does not implement IUserConfirmationStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserEmailStore":
                return "Store does not implement IUserEmailStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserLockoutStore":
                return "Store does not implement IUserLockoutStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserLoginStore":
                return "Store does not implement IUserLoginStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserPasswordStore":
                return "Store does not implement IUserPasswordStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserPhoneNumberStore":
                return "Store does not implement IUserPhoneNumberStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserRoleStore":
                return "Store does not implement IUserRoleStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserSecurityStampStore":
                return "Store does not implement IUserSecurityStampStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "StoreNotIUserTwoFactorStore":
                return "Store does not implement IUserTwoFactorStore&lt;TUser&gt;";
                //error when the store does not implement this interface
              
              case "UserAlreadyHasPassword":
                return "User already has a password set";
                //error when AddPassword called when a user already has a password
              
              case "UserAlreadyInRole":
                return "User already in role";
                //Error when a user is already in a role
              
              case "UserIdNotFound":
                return "Contraseña o Nombre de Usuario incorrecto";
                //No user with this id found
              
              case "UserNameNotFound":
                return "Contraseña o Nombre de Usuario incorrecto";
                //error when a user does not exist
              
              case "UserNotInRole":
                return "User is not in role";
                //Error when a user is not in the role
              
              default:  
                return "Ops parece que hemos cometido un error";
                //Default identity result error message
            }
        }
    }
}