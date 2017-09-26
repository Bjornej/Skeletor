using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Microsoft.Extensions.DependencyModel;

namespace Skeletor.Tests.Unit
{
    public class TypeHelpersTests
    {
        public class TestCommand : Command { }

        public class TestCommand2 : Command { }

        public class TestHandler : ICommandHandler<TestCommand>
        {
            public void Handle(TestCommand command)
            {
                throw new NotImplementedException();
            }
        }

        public class TestHandler2 : ICommandHandler<TestCommand>, ICommandHandler<TestCommand2>
        {
            public void Handle(TestCommand2 command)
            {
                throw new NotImplementedException();
            }

            public void Handle(TestCommand command)
            {
                throw new NotImplementedException();
            }
        }

        public class IsCommandHandler
        {
            [Fact]
            public void ShoudReturnFalseifTypeIsNotACommandHandler()
            {
                var type = typeof(TypeToRegister);

                Assert.False(type.GetTypeInfo().IsCommandHandler());
            }

            [Fact]
            public void ShoudReturnTrueifTypeIsACommandHandler()
            {
                var type = typeof(TestHandler);

                Assert.True(type.GetTypeInfo().IsCommandHandler());
            }
        }

        public class GetCommandHandlers
        {
            [Fact]
            public void ShouldFindHandlers()
            {
                var res = TypeHelpers.GetCommandHandlers(new List<Assembly>() { Assembly.Load(new AssemblyName("Skeletor.Tests.Unit")) });

                Assert.Contains(res,x => x.Interface == typeof(ICommandHandler<TestCommand>) && x.Type == typeof(TestHandler));
                Assert.Contains(res, x => x.Interface == typeof(ICommandHandler<TestCommand>) && x.Type == typeof(TestHandler2));
                Assert.Contains(res, x => x.Interface == typeof(ICommandHandler<TestCommand2>) && x.Type == typeof(TestHandler2));
            }
        }

        public class GetCommandHandlerInterfaces
        {
            [Fact]
            public void ShouldGetSingleInterface() {
                var type = typeof(TestHandler);

                Assert.Equal(type.GetTypeInfo().GetCommandHandlerInterfaces().Count(),1);
            }

            [Fact]
            public void ShouldGetRightInterface()
            {
                var type = typeof(TestHandler);

                Assert.Equal(type.GetTypeInfo().GetCommandHandlerInterfaces().First().Interface, typeof(ICommandHandler<TestCommand>));
            }

            [Fact]
            public void ShouldGetRightType()
            {
                var type = typeof(TestHandler);

                Assert.Equal(type.GetTypeInfo().GetCommandHandlerInterfaces().First().Type, typeof(TestHandler));
            }

            [Fact]
            public void ShouldGetMultipleInterfaces()
            {
                var type = typeof(TestHandler2);

                Assert.Equal(type.GetTypeInfo().GetCommandHandlerInterfaces().Count(), 2);
            }

            public void ShouldGetRightInterfaceMultipleFirst()
            {
                var type = typeof(TestHandler);

                Assert.Equal(type.GetTypeInfo().GetCommandHandlerInterfaces().First().Interface, typeof(ICommandHandler<TestCommand>));
            }

            [Fact]
            public void ShouldGetRightTypeMultipleFirst()
            {
                var type = typeof(TestHandler);

                Assert.Equal(type.GetTypeInfo().GetCommandHandlerInterfaces().First().Type, typeof(TestHandler));
            }

            public void ShouldGetRightInterfaceMultipleSecond()
            {
                var type = typeof(TestHandler);

                Assert.Equal(type.GetTypeInfo().GetCommandHandlerInterfaces().First().Interface, typeof(ICommandHandler<TestCommand2>));
            }

            [Fact]
            public void ShouldGetRightTypeMultipleSecond()
            {
                var type = typeof(TestHandler);

                Assert.Equal(type.GetTypeInfo().GetCommandHandlerInterfaces().First().Type, typeof(TestHandler));
            }

        }
    }
}
