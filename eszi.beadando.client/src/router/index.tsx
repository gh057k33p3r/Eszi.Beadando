import { createBrowserRouter } from "react-router";
import { Layout } from "../components/Layout/Layout";
import { HomePage } from "../pages/HomePage";
import { WeatherForecastsPage } from "../pages/WeatherForecastsPage";
import { AuthenticatedLayout } from "../components/Layout/AuthenticatedLayout";

export const router = createBrowserRouter([
  {
    element: <Layout />,
    children: [
      {
        path: "/",
        element: <HomePage />,
      },
      {
        element: <AuthenticatedLayout />,
        children: [
          {
            path: "weather-forecasts",
            element: <WeatherForecastsPage />,
          },
        ],
      },
    ],
  },
]);
