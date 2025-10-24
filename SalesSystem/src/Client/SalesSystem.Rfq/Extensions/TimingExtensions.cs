namespace SalesSystem.Rfq.Extensions
{
    public static class TimingExtensions
    {
        public static async Task<(long elapsedMilliseconds, int count, List<T> result)> TimeAsyncGuidService<T>(
            this Func<Guid, Task<List<T>>> operation, 
            Guid id) where T : class
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<T> result = await operation(id);

            stopwatch.Stop();

            return (stopwatch.ElapsedMilliseconds, result.Count, result);
        }
        public static async Task<(long elapsedMilliseconds, int count, List<T> result)> TimeAsyncStringService<T>(
            this Func<string, Task<List<T>>> operation,
            string id) where T : class
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<T> result = await operation(id);

            stopwatch.Stop();

            return (stopwatch.ElapsedMilliseconds, result.Count, result);
        }

        public static async Task<(long elapsedMilliseconds, int count, List<T> result)> TimeAsyncService<T>(
            this Func<Task<List<T>>> operation) where T : class
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<T> result = await operation();

            stopwatch.Stop();

            return (stopwatch.ElapsedMilliseconds, result.Count, result);
        }

        public static async Task<(long elapsedMilliseconds, int count, List<T> result)> TimeAsyncCollectionService<T, C>(
            this Func<ICollection<C>, Task<List<T>>> operation,
            ICollection<C> collection) where T : class
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<T> result = await operation(collection);

            stopwatch.Stop();

            return (stopwatch.ElapsedMilliseconds, result.Count, result);
        }

        public static async Task<(long elapsedMilliseconds, int count, List<T> result)> TimeAsyncListService<T, C>(
            this Func<IList<C>, Task<List<T>>> operation,
            IList<C> list) where T : class
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<T> result = await operation(list);

            stopwatch.Stop();

            return (stopwatch.ElapsedMilliseconds, result.Count, result);
        }
        public static async Task<(long elapsedMilliseconds, int count)> TimeAsyncGuidIntService(
            this Func<Guid, Task<int>> operation,
            Guid id)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = await operation(id);

            stopwatch.Stop();

            return (stopwatch.ElapsedMilliseconds, result);
        }
        public static async Task<(long elapsedMilliseconds, int count)> TimeAsyncVoidIntService(
            this Func<Task<int>> operation)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = await operation();

            stopwatch.Stop();

            return (stopwatch.ElapsedMilliseconds, result);
        }
    }
}