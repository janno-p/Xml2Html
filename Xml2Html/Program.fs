module Xml2Html.Program

open Suave.Log
open Suave.Http
open Suave.Http.Applicatives
open Suave.Http.Successful
open Suave.Web

let logger = Loggers.sane_defaults_for Debug

let application =
    choose [
        log logger log_format >>= never
        url "/hello" >>= never >>= OK "Never executes"
        url "/hello" >>= OK "Hello, World!"
        url "/quit" >>= warbler (fun _ -> System.Environment.Exit(0); never)
        RequestErrors.NOT_FOUND "Found no handlers"
    ]

web_server default_config application
