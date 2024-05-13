using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace LineProgress.Tests.Infrastructure
{
    public class MockConfiguration : IConfiguration
    {
        public string? this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString(string name)
        {
            // テスト用の接続文字列を返す
            return "test_connection_string";
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public string GetSection(string key)
        {
            // テスト用のセクション情報を返す
            return "test_section_value";
        }

        IConfigurationSection IConfiguration.GetSection(string key)
        {
            throw new NotImplementedException();
        }
    }

}
