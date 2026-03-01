using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ST.Shared.Services
{
    public class LockManager
    {
        List<SemaphoreSlim> SemaphoreSlim;
        private int count;
        public LockManager(int count)
        {
            this.count = count;
            SemaphoreSlim = new List<SemaphoreSlim>();
            for (int i = 0; i < count; i++)
            {
                SemaphoreSlim.Add(new SemaphoreSlim(1, 1));
            }
        }

        public SemaphoreSlim Get(int i)
        {
            return SemaphoreSlim[i % count];
        }
        public SemaphoreSlim Get(string code)
        {
            return SemaphoreSlim[code.Sum(c => c) % count];
        }
        public SemaphoreSlim Get(Guid code)
        {
            return SemaphoreSlim[code.ToByteArray().Sum(c => c) % count];
        }
        public SemaphoreSlim Get(double code)
        {
            var i = Convert.ToInt32(Math.Floor(code));
            return SemaphoreSlim[i % count];
        }
        public SemaphoreSlim Get(decimal code)
        {
            var i = Convert.ToInt32(Math.Floor(code));
            return SemaphoreSlim[i % count];
        }



        public T Lock<T>(int i, Func<T> func)
        {
            return Lock(this.Get(i), func);
        }
        public T Lock<T>(string code, Func<T> func)
        {
            return Lock(this.Get(code), func);
        }
        public T Lock<T>(Guid code, Func<T> func)
        {
            return Lock(this.Get(code), func);
        }
        public T Lock<T>(double code, Func<T> func)
        {
            return Lock(this.Get(code), func);
        }
        public T Lock<T>(decimal code, Func<T> func)
        {
            return Lock(this.Get(code), func);
        }
        public async Task<T> LockAsync<T>(int i, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(i), func);
        }
        public async Task<T> LockAsync<T>(string code, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(code), func);
        }
        public async Task<T> LockAsync<T>(Guid code, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(code), func);
        }
        public async Task<T> LockAsync<T>(double code, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(code), func);
        }
        public async Task<T> LockAsync<T>(decimal code, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(code), func);
        }
        public void Lock(int i, Action func)
        {
            Lock(this.Get(i), func);
        }
        public void Lock(string code, Action func)
        {
            Lock(this.Get(code), func);
        }
        public void Lock(Guid code, Action func)
        {
            Lock(this.Get(code), func);
        }
        public void Lock(double code, Action func)
        {
            Lock(this.Get(code), func);
        }
        public void Lock(decimal code, Action func)
        {
            Lock(this.Get(code), func);
        }
        public async Task LockAsync(int i, Func<Task> func)
        {
            await LockAsync(this.Get(i), func);
        }
        public async Task LockAsync(string code, Func<Task> func)
        {
            await LockAsync(this.Get(code), func);
        }
        public async Task LockAsync(Guid code, Func<Task> func)
        {
            await LockAsync(this.Get(code), func);
        }
        public async Task LockAsync(double code, Func<Task> func)
        {
            await LockAsync(this.Get(code), func);
        }
        public async Task LockAsync(decimal code, Func<Task> func)
        {
            await LockAsync(this.Get(code), func);
        }






        public (T result, bool success) Lock<T>(int i, TimeSpan timeOut, Func<T> func)
        {
            return Lock(this.Get(i), timeOut, func);
        }
        public (T result, bool success) Lock<T>(string code, TimeSpan timeOut, Func<T> func)
        {
            return Lock(this.Get(code), timeOut, func);
        }
        public (T result, bool success) Lock<T>(Guid code, TimeSpan timeOut, Func<T> func)
        {
            return Lock(this.Get(code), timeOut, func);
        }
        public (T result, bool success) Lock<T>(double code, TimeSpan timeOut, Func<T> func)
        {
            return Lock(this.Get(code), timeOut, func);
        }
        public (T result, bool success) Lock<T>(decimal code, TimeSpan timeOut, Func<T> func)
        {
            return Lock(this.Get(code), timeOut, func);
        }
        public async Task<(T result, bool success)> LockAsync<T>(int i, TimeSpan timeOut, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(i), timeOut, func);
        }
        public async Task<(T result, bool success)> LockAsync<T>(string code, TimeSpan timeOut, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(code), timeOut, func);
        }
        public async Task<(T result, bool success)> LockAsync<T>(Guid code, TimeSpan timeOut, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(code), timeOut, func);
        }
        public async Task<(T result, bool success)> LockAsync<T>(double code, TimeSpan timeOut, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(code), timeOut, func);
        }
        public async Task<(T result, bool success)> LockAsync<T>(decimal code, TimeSpan timeOut, Func<Task<T>> func)
        {
            return await LockAsync(this.Get(code), timeOut, func);
        }
        public bool Lock(int i, TimeSpan timeOut, Action func)
        {
            return Lock(this.Get(i), timeOut, func);
        }
        public bool Lock(string code, TimeSpan timeOut, Action func)
        {
            return Lock(this.Get(code), timeOut, func);
        }
        public bool Lock(Guid code, TimeSpan timeOut, Action func)
        {
            return Lock(this.Get(code), timeOut, func);
        }
        public bool Lock(double code, TimeSpan timeOut, Action func)
        {
            return Lock(this.Get(code), timeOut, func);
        }
        public bool Lock(decimal code, TimeSpan timeOut, Action func)
        {
            return Lock(this.Get(code), timeOut, func);
        }
        public async Task<bool> LockAsync(int i, TimeSpan timeOut, Func<Task> func)
        {
            return await LockAsync(this.Get(i), timeOut, func);
        }
        public async Task<bool> LockAsync(string code, TimeSpan timeOut, Func<Task> func)
        {
            return await LockAsync(this.Get(code), timeOut, func);
        }
        public async Task<bool> LockAsync(Guid code, TimeSpan timeOut, Func<Task> func)
        {
            return await LockAsync(this.Get(code), timeOut, func);
        }
        public async Task<bool> LockAsync(double code, TimeSpan timeOut, Func<Task> func)
        {
            return await LockAsync(this.Get(code), timeOut, func);
        }
        public async Task<bool> LockAsync(decimal code, TimeSpan timeOut, Func<Task> func)
        {
            return await LockAsync(this.Get(code), timeOut, func);
        }





        private T Lock<T>(SemaphoreSlim semaphore, Func<T> c)
        {
            T result = default(T);
            semaphore.Wait();
            try
            {
                result = c();
            }
            catch (Exception ex)
            {
                semaphore.Release();
                throw;
            }
            semaphore.Release();
            return result;
        }

        private async Task<T> LockAsync<T>(SemaphoreSlim semaphore, Func<Task<T>> c)
        {
            T result = default(T);
            semaphore.Wait();
            try
            {
                result = await c();
            }
            catch (Exception ex)
            {
                semaphore.Release();
                throw;
            }
            semaphore.Release();
            return result;
        }
        private void Lock(SemaphoreSlim semaphore, Action c)
        {
            semaphore.Wait();
            try
            {
                c();
            }
            catch (Exception ex)
            {
                semaphore.Release();
                throw;
            }
            semaphore.Release();
        }
        private async Task LockAsync(SemaphoreSlim semaphore, Func<Task> c)
        {
            semaphore.Wait();
            try
            {
                await c();
            }
            catch (Exception ex)
            {
                semaphore.Release();
                throw;
            }
            semaphore.Release();
        }





        private (T result, bool success) Lock<T>(SemaphoreSlim semaphore, TimeSpan timeOut, Func<T> c)
        {
            T result = default(T);
            var sc = semaphore.Wait(timeOut);
            if (sc)
            {
                try
                {
                    result = c();
                }
                catch (Exception ex)
                {
                    semaphore.Release();
                    throw;
                }
                semaphore.Release();
            }
            return (result, sc);
        }

        private async Task<(T result, bool success)> LockAsync<T>(SemaphoreSlim semaphore, TimeSpan timeOut, Func<Task<T>> c)
        {
            T result = default(T);
            var s = await semaphore.WaitAsync(timeOut);
            if (s)
            {
                try
                {
                    result = await c();
                }
                catch (Exception ex)
                {
                    semaphore.Release();
                    throw;
                }
                semaphore.Release();
            }
            return (result, s);
        }
        private bool Lock(SemaphoreSlim semaphore, TimeSpan timeOut, Action c)
        {
            var s = semaphore.Wait(timeOut);
            if (s)
            {
                try
                {
                    c();
                }
                catch (Exception ex)
                {
                    semaphore.Release();
                    throw;
                }
                semaphore.Release();
            }
            return s;
        }
        private async Task<bool> LockAsync(SemaphoreSlim semaphore, TimeSpan timeOut, Func<Task> c)
        {
            var s = await semaphore.WaitAsync(timeOut);
            if (s)
            {
                try
                {
                    await c();
                }
                catch (Exception ex)
                {
                    semaphore.Release();
                    throw;
                }
                semaphore.Release();
            }
            return s;
        }



        #region
        private static Dictionary<string, LockManager> managers = new Dictionary<string, LockManager>(); 
        public static LockManager GetOrCreate(string name, int count)
        {
            lock (managers)
            {
                if (managers.ContainsKey(name))
                    return managers[name];
                managers[name] = new LockManager(count);
                return managers[name];
            }
        }
        public static LockManager GetOrCreate(string name)
        {
            return GetOrCreate(name, 1);
        }
        #endregion
    }
}
