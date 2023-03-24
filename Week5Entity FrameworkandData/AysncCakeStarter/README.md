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

# GitHub Questions - Asynchronous Programming
 
- Why do we need to use asynchronous methods?

Async methods allow us to execute methods in parrallel with other methods, this is useful for doing other tasks whilst waiting for one large method to finish instead of waiting for the large/long task to finish

- What keywords should an asynchronous method use (and where?)

Task, This denotes the data type that the method returns although Task on it's own denotes void
Async, This needs to be in the method signature
Await, await means wait for this method to finish before moving on
.Result, does the same thing as await, wait for it to finish


- What return types are allowed for asynchronous methods?

Tasks are the primary way of denoting the return type, on it's own it means void but with the <> you can note the class returns

- What effect does the await keyword have?

Await, await means wait for this method to finish before moving on
.Result, does the same thing as await, wait for it to finish

- What is the naming convention for asynchronous methods?

Having Async after the method name.
