using System.Net.Http.Headers;

namespace TheLockedDoorProgram
{
    public class Door
    {
        public ChestState _state { get; set; }
        private string _doorPassword;

        public Door(string password)
        {
           _doorPassword = password;
        }

        public void Open()
        {
            if (this._state != ChestState.locked) this._state = ChestState.open;
        }

        public void Close()
        {
            if (this._state == ChestState.open) this._state = ChestState.closed;
        }

        public void Lock()
        {
            if (this._state == ChestState.closed) this._state = ChestState.locked;
        }

        public void Unlock()
        {
            Console.Write("Enter the password: ");
            string password = Console.ReadLine();

            if (this._state == ChestState.locked && this._doorPassword == password)
            {
                this._state = ChestState.closed;
            }
            else { Console.WriteLine("Password is incorrect!"); }
        }

        public void ChangeCode()
        {
            Console.Write("Enter the old password: ");
            string old_password = Console.ReadLine();
            if (old_password == this._doorPassword)
            {
                this._doorPassword = old_password;
            }
            else { Console.WriteLine("Old password is incorrect!"); }
        }

        static void Main()
        {
            string initial_password;
            do
            {
                Console.Write("Enter your door password: ");
                initial_password = Console.ReadLine();
            }
            while (initial_password == null);

            Door door = new Door(initial_password);

            while (true)
            {
                Console.WriteLine();
                Console.Write($"The door is {door._state}. What is your desire? You can do the following: open, close, lock, unlock, change password: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "open":
                        door.Open();
                        break;
                    case "close":
                        door.Close();
                        break;
                    case "lock":
                        door.Lock();
                        break;
                    case "unlock":
                        door.Unlock();
                        break;
                    case "change password":
                        door.ChangeCode();
                        break;
                }
            }

        }
    }
}

public enum ChestState { locked, open, closed }