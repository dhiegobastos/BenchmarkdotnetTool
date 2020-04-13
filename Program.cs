using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkdotnetTool;

namespace MyBenchmarks
{
    //[SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)]
    //[SimpleJob(RuntimeMoniker.Mono)]
    [RPlotExporter]
    public class CpfValidatorBenchmark
    {
        public CpfValidatorBenchmark()
        {

        }

        [Benchmark]
        public void ValidacaoClassica() => CpfValidatorPerformance.ValidarCPFClassico("10474916642");

        [Benchmark]
        public void ValidacaoOtimizada() => new CpfValidatorPerformance.Cpf("10474916642").ToString();

        [Benchmark]
        public void ValidacaoStackalloc() => CpfValidatorPerformance.ValidarCPFStackalloc("10474916642");
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // var summary = BenchmarkRunner.Run<Md5VsSha256>();
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
        }
    }
}
