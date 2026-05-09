import {useState} from "react";
import type {CreateLinkResponse} from "../types/api.ts";

export default function HomePage() {
  const [url, setUrl] = useState("")
  const [shortCode, setShortCode] = useState("")

  const handleShortenUrl = () => {
    fetch("/api/v1/Link", {
      method: 'POST',
      headers: {'content-type': 'application/json'},
      mode: 'cors',
      body: JSON.stringify({"Url": url}),
    }).then(async res => {
      if (!res.ok) {
        throw new Error(`Request failed: ${res.status}`)
      }
      const data: CreateLinkResponse = await res.json();
      setShortCode(data.shortCode)
    })
  };

  return (
    <>
      <section id="center">
        <header>
          <h1>MinUrl</h1>
        </header>

        <div className="card">
          <div className="cardRow">
            <span>Original URL:</span>
            <input type="url" value={url} onChange={(e) => setUrl(e.target.value)}/>
          </div>
          <div className="cardRow">
            <span>Shortcode:</span>
            <input type="text" readOnly value={shortCode}/>
          </div>
          <button type="button" className="shorten" onClick={handleShortenUrl}>Generate Short Code</button>
        </div>
      </section>
    </>
  )
}