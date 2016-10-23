const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
var ExtractTextPlugin = require("extract-text-webpack-plugin");


module.exports = {
    context: path.join(__dirname, "src"),
    entry: {
        app: "./app/main.ts"
    },
    output: {
        path: path.join(__dirname, "dist"),
        filename: "[name].bundle.js"
    },
    devtool: 'source-map',
    resolve: {
        extensions: ['', '.webpack.js', '.web.js', '.ts', '.js']
    },
    plugins: [
   new HtmlWebpackPlugin({
       template: './index.html',
       minify: {
           collapseWhitespace: true,
           removeComments: true,
           removeRedundantAttributes: true,
           removeScriptTypeAttributes: true,
           removeStyleLinkTypeAttributes: true
       }
   }),
       new ExtractTextPlugin("styles.css")
    ],
    module: {
        loaders: [
            { test: /\.scss$/, loader: ExtractTextPlugin.extract(['css', 'resolve-url', 'sass']) },
            { test: /\.woff2?$|\.ttf$|\.eot$|\.svg$/, loader: 'file' },
            { test: /\.ts$/, loaders: ["ng-annotate", "ts"] }
        ]
    }
};