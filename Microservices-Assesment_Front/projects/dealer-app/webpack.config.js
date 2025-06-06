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
    uniqueName: "dealerApp",
    publicPath: "auto",
    scriptType:"text/javascript"
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
        // library: { type: "module" },

        // For remotes (please adjust)
        name: "dealerApp",
        filename: "DealerEntry.js",
        exposes: {
            './DealerPanelModule': './projects/dealer-app/src/app/dealer-panel/dealer-panel.module.ts',
        },        
        
        // For hosts (please adjust)
        // remotes: {
        //     "hostApp": "http://localhost:4200/remoteEntry.js",
        //     "mfeApp": "http://localhost:4300/remoteEntry.js",
        //     "saleApp": "http://localhost:4400/remoteEntry.js",
        //     "adminApp": "http://localhost:4500/remoteEntry.js",

        // },

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
