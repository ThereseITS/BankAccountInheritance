namespace BankAccountInheritance
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            BankAccount[] bcs = new BankAccount[3];

            bcs[0] = new BankAccount(200m);         
            bcs[1] = new CurrentAccount(300m,100m);
            bcs[2] = new CurrentAccount(0,500m);

     // Try and withdraw 500 from each account       

            foreach (BankAccount bc in bcs)
            {
                bc.ToString();
                Console.WriteLine(bc.ToString());
                Console.WriteLine($"You have withdrawn {bc.Withdraw(500)} from {bc.AccountNumber} Balance now {bc.Balance}");
                bc.ToString();
                Console.WriteLine("------------");
            }

            Console.WriteLine(" Withdrawing money from empty accounts");

            foreach (BankAccount bc in bcs)
            {
                bc.ToString();
                Console.WriteLine($"You have withdrawn {bc.Withdraw(500)} from {bc.AccountNumber} Balance now {bc.Balance}");
                bc.ToString();
                Console.WriteLine("------------");
            }


            Console.WriteLine(" Lodging money ");

            foreach (BankAccount bc in bcs)
            {
                bc.ToString();
                Console.WriteLine($"You have lodged 300 to {bc.AccountNumber} Balance now: {bc.Lodge(300)}");
              
                Console.WriteLine("------------");
            }
            //Note that to use the child class method, the object needs to be explicitly declared as a member of the child class

            CurrentAccount c = new CurrentAccount(500m, 500m);
            Console.WriteLine("------------");

            Console.WriteLine("Re-Setting the overdraft limit");

            Console.WriteLine(c.ToString());
            c.SetNewOverdraft(100);
            Console.WriteLine(c.ToString());
        }
    }
}