# Asynchronous Programming

To have a method be async you need to mark the method with async and return a 'Task' of the class or type you want to return

        private static async Task<Cake> BakeCake()
        {
            Console.WriteLine("Cake is in the oven");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Cake is done");
            return new Cake();
        }
 A common problem can happen where the async method takes too long and only returns the task not the type

 So to get around that you would have another await in the origional loop

             var cakeTask = BakeCakeAsync();
            PlayPartyGames();
            OpenPresents();
            var cake = await cakeTask;

**Important** this will need to have a chain of awaits upto the origional method

Or you can use cakeTask.Result, this forces the method to stop until a result is provided