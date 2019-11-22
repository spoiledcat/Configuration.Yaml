using Microsoft.Extensions.Configuration;
using System;
using YamlDotNet.Core;
using System.IO;

namespace SpoiledCat.Extensions.Configuration
{
    public class YamlConfigurationProvider : FileConfigurationProvider
    {
        public YamlConfigurationProvider(YamlConfigurationSource source) : base(source) { }

        public override void Load(Stream stream)
        {
            var parser = new YamlConfigurationFileParser();
            try
            {
                Data = parser.Parse(stream);
            }
            catch (YamlException e)
            {
                throw new FormatException(e.Message, e);
            }
        }
    }
}
