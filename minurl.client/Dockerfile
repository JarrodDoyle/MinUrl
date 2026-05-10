FROM node:slim AS builder
WORKDIR /app

USER $APP_UID
EXPOSE 3000

COPY package*.json ./
RUN npm ci
COPY . .
RUN npm run build

FROM nginx:stable-alpine
COPY --from=builder /app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/templates/default.conf.template
RUN chmod -R 755 /usr/share/nginx/html