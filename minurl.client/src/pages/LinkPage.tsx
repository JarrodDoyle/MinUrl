import {useNavigate, useParams} from "react-router";
import type {GetLinkDetailsResponse} from "../types/api.ts";

export default function LinkPage() {
  const {shortCode} = useParams();
  const navigate = useNavigate();

  fetch(`/api/v1/Link/${shortCode}`).then(async res => {
    if (!res.ok) {
      navigate('/');
    }

    const data: GetLinkDetailsResponse = await res.json();
    window.location.replace(data.originalUrl);
  });

  return null;
}