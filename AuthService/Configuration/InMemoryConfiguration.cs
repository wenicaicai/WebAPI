using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace AuthService.Configuration
{
    /// <summary>
    /// 签名：一对公钥、秘钥
    /// </summary>
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                //{name:social-network,displayName:社交网络}
                new ApiResource("socialnetwork","社交网络-多")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "socialnetwork",
                    //用于
                    ClientSecrets = new[] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new[] { "socialnetwork" }
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                //用于测试
                new TestUser
                {
                    SubjectId ="1",
                    Username = "1216040822@qq.com",
                    Password = "2020"
                }
            };
        }
    }
}
