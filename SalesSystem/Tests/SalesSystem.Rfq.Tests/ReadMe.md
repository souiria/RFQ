# SalesSystem.Rfq.Tests Timing Tests
# ================================

## How to run Timing Tests

Start the Aspire application and ensure it is running, then execute the following commands in the terminal:


            ```
                # Run all timing tests
                dotnet test --filter Category=Timing

                # Run specific test
                dotnet test --filter GetCustomersAsync_TimingTest_WithMockData

                # Run benchmarks (optional)
                dotnet test --filter Category=Benchmark
            ```

## How to run Live Tests

Start the Aspire application and ensure it is running, then execute the following commands in the terminal:


            ```
                # Run all live tests
                dotnet test --filter Category=Live

                # Run just the main benchmark test
                dotnet test --filter GetCustomersAsync_LiveService_BenchmarkWithSpecificUserId

                # Run consistency tests
                dotnet test --filter Category=Performance
            ```


