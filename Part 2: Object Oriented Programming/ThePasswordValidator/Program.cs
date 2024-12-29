namespace ThePasswordValidator
{
    class PasswordValidator
    {
        private string _password;

        public PasswordValidator(string password)
        {
            _password = password;
        }

        public bool ValidatePassword(string password)
        {
            int i = 0;

            if (password.Length > 13 || password.Length < 6) { return false; }

            foreach (char c in password) { if (c == '&' || c == 'T') return false; }

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    i++; break;
                }
            }

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    i++; break;
                }
            }

            foreach (char c in password)
            {
                if (char.IsLower(c))
                {
                    i++; break;
                }
            }

            Console.WriteLine($"i = {i}");
            if (i == 3) { return true; } else { return false; }
        }
    }

    class MainProgram
    {
        static public void Main()
        {
            Console.WriteLine("Welcome to the password validator!");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter your password: ");
                string your_password = Console.ReadLine();
                
                switch (new PasswordValidator(your_password).ValidatePassword(your_password))
                {
                    case true:  Console.WriteLine("Your password is valid ;)"); break;
                    case false: Console.WriteLine("Your password is invalid ;("); break;
                }
            }
        }
    }
}