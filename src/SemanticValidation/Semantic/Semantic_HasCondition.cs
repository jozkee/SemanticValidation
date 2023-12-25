﻿using Microsoft.SemanticKernel;
using System.Text.Json;
using SemanticValidation.Models;

namespace SemanticValidation
{
    public partial class Semantic
    {
        public async Task<SemanticValidationResult> HasConditionAsync(string text, string condition)
        {
            var skResult = (
                await HasConditionFunc.InvokeAsync(TestKernel, new KernelArguments()
                {
                    ["text"] = text,
                    ["condition"] = condition
                })
            ).GetValue<string>() ?? "";

            var result = JsonSerializer.Deserialize<SemanticValidationResult>(skResult);

            if (result is null)
                throw new InvalidOperationException("Can not assert Similarity");

            return result;
        }
    }
}
