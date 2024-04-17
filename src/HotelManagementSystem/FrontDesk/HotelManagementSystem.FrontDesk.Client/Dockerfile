# Stage 1: Build Angular app
FROM node:latest as build

WORKDIR /app
COPY ./FrontDesk/HotelManagementSystem.FrontDesk.Client/ /app/
RUN npm install
RUN npm run build

# # Stage 2: Setup Nginx to serve Angular app
FROM nginx:latest
COPY --from=build /app/dist/hotel-management-system.front-desk.client/browser /usr/share/nginx/html
EXPOSE 80