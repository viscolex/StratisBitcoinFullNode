﻿using System.IO;
using System.Linq;
using Mono.Cecil;

namespace Stratis.SmartContracts.Core.ContractValidation
{
    public class SmartContractDecompiler
    {
        public SmartContractDecompilation GetModuleDefinition(byte[] bytes, IAssemblyResolver assemblyResolver = null)
        {
            // TODO: Ensure that AppContext.BaseDirectory is robust here
            IAssemblyResolver resolver = assemblyResolver ?? new DefaultAssemblyResolver();
            SmartContractDecompilation result = new SmartContractDecompilation();
            result.ModuleDefinition = ModuleDefinition.ReadModule(new MemoryStream(bytes), new ReaderParameters { AssemblyResolver = resolver });
            result.ContractType = result.ModuleDefinition.Types.FirstOrDefault(x => x.FullName != "<Module>");
            return result;
        }
    }
}