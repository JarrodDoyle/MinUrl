import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from "path"

// https://vite.dev/config/
export default defineConfig({
  base: '/',
  plugins: [react()],
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5199',
        changeOrigin: true,
      }  
    },
  },
  build: {
    rollupOptions: {},
    commonjsOptions: {
      include: [/node_modules/],
    },
  },
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
    dedupe: ['react', 'react-dom', 'prop-types'],
  },
  optimizeDeps: {
    include: ['react', 'react-dom', 'prop-types'],
  },
})
