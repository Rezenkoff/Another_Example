﻿using MediatR;
using Monitor.Application.Interfaces;
using Monitor.Application.MonitoringChecks.ChecksLogic;
using Monitor.Application.MonitoringChecks.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Application.MonitoringChecks.Commands
{

    public class LoginCheckProdCommand : IRequest<CommandResult> //, ICommand<CommandResult>
    {
        public CheckSettings CheckSettings => new CheckSettings
        {
            Priority = PrioritiesEnum.Medium,
            Service = "Unit test execution: 'AutodocAutoTest.TestsCases.Login'",
            Type = CheckTypeEnum.LoginUnitTestProd,
            EnvironmentId = (int)EnvironmentsEnum.Prod,
            CheckFullDescription = "Результаты запуска юнит теста 'AutodocAutoTest.TestsCases.Login'"
        };
    }

    public class LoginCheckProdHandler : IRequestHandler<LoginCheckProdCommand, CommandResult>
    {
        private readonly IUnitTestsProcessorService _processor;

        public LoginCheckProdHandler(IUnitTestsProcessorService processor)
        {
            _processor = processor ?? throw new ArgumentNullException(nameof(IUnitTestsProcessorService));
        }

        public async Task<CommandResult> Handle(LoginCheckProdCommand request, CancellationToken cancellationToken)
        {
            var path = @"E:\Vodolazkiy\autodocautotest\AutodocAutoTests\bin\Debug\AutodocAutoTest.dll";
            var testName = "AutodocAutoTest.TestsCases.Login";

            var result = new CommandResult { Success = true };
            var check = new UnitTestCheck(_processor);
            result.CheckModel = await check.RunNUnitTest(request.CheckSettings, testName, path);
            return result;
        }
    }
}
