using Microsoft.AspNetCore.Identity;

namespace EasyCashIdentityProject.PresentationLayer.Models
{
	public class CustomIdentityValidator : IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Password must be at least {length} character"
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Please enter at least one uppercase letter"
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Please enter at least one lowercase letter"
			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Please enter at least one number"
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Please enter at least one symbol"
			};
		}

		public override IdentityError InvalidEmail(string email)
		{
			return new IdentityError()
			{
				Code = "InvalidEmail",
				Description = "Please enter a valid e-mail address"
			};
		}

		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError()
			{
				Code = "DuplicateEmail",
				Description = "There is a registered user with this e-mail, please change your e-mail"
			};
		}

		public override IdentityError PasswordMismatch()
		{
			return new IdentityError
			{
				Code = "PasswordMismatch",
				Description = "The entered password is incorrect"
			};
		}

		public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUniqueChars",
				Description = $"Password must have at least {uniqueChars} unique characters"
			};
		}
		

		public override IdentityError InvalidUserName(string userName)
		{
			return new IdentityError
			{
				Code = "InvalidUserName",
				Description = "Invalid characters in the username"
			};
		}

		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError
			{
				Code = "DuplicateUserName",
				Description = "This username is already taken, please choose a different one"
			};
		}

	
		public override IdentityError DefaultError()
		{
			return new IdentityError
			{
				Code = "DefaultError",
				Description = "An error occurred during registration"
			};
		}  
	}
}
