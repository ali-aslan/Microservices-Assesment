const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");
const mf = require("@angular-architects/module-federation/webpack");
const path = require("path");
const share = mf.share;

const sharedMappings = new mf.SharedMappings();
sharedMappings.register(
  path.join(__dirname, '../../tsconfig.json'),
  [/* mapped paths to share */]);

module.exports = {
  output: {
    uniqueName: "hostApp",
    publicPath: "auto",
    scriptType: "text/javascript"
  },
  optimization: {
    runtimeChunk: false
  },   
  resolve: {
    alias: {
      ...sharedMappings.getAliases(),
    }
  },
  experiments: {
    outputModule: true
  },
  plugins: [
    new ModuleFederationPlugin({

        // For remotes (please adjust)
        name: "hostApp",
        // filename: "remoteEntry.js",
        // exposes: {
        //     './Component': './projects/host-app/src/app/app.component.ts',
        // },        
        
        // For hosts (please adjust)
        remotes: {
            "mfeApp": "mfeApp@http://localhost:4300/remoteEntry.js",
            "saleApp": "saleApp@http://localhost:4400/SaleEntry.js",
            "adminApp": "adminApp@http://localhost:4500/AdminEntry.js",
            "dealerApp": "dealerApp@http://localhost:4600/DealerEntry.js",
        },

        shared: share({
          "@angular/core": { singleton: true, strictVersion: true, requiredVersion: 'auto' }, 
          "@angular/common": { singleton: true, strictVersion: true, requiredVersion: 'auto' }, 
          "@angular/common/http": { singleton: true, strictVersion: true, requiredVersion: 'auto' }, 
          "@angular/router": { singleton: true, strictVersion: true, requiredVersion: 'auto' },

          ...sharedMappings.getDescriptors()
        })
        
    }),
    sharedMappings.getPlugin()
  ],
};
