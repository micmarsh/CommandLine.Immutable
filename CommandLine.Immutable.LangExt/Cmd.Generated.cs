// using System.CommandLine;
// using LanguageExt;
// namespace CommandLine.Immutable;
//
// public readonly partial record struct Cmd<A>
// {
//     public Cmd<A> WithAction(Func<A, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A> WithAction(Func<A, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a) => action(a).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B>
// {
//     public Cmd<A, B> WithAction(Func<A, B, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B> WithAction(Func<A, B, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b) => action(a, b).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C>
// {
//     public Cmd<A, B, C> WithAction(Func<A, B, C, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C> WithAction(Func<A, B, C, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c) => action(a, b, c).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C, D>
// {
//     public Cmd<A, B, C, D> WithAction(Func<A, B, C, D, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult),
// 					self.inputD.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C, D> WithAction(Func<A, B, C, D, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c, d) => action(a, b, c, d).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C, D, E>
// {
//     public Cmd<A, B, C, D, E> WithAction(Func<A, B, C, D, E, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult),
// 					self.inputD.GetValue(parseResult),
// 					self.inputE.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C, D, E> WithAction(Func<A, B, C, D, E, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c, d, e) => action(a, b, c, d, e).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C, D, E, F>
// {
//     public Cmd<A, B, C, D, E, F> WithAction(Func<A, B, C, D, E, F, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult),
// 					self.inputD.GetValue(parseResult),
// 					self.inputE.GetValue(parseResult),
// 					self.inputF.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C, D, E, F> WithAction(Func<A, B, C, D, E, F, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c, d, e, f) => action(a, b, c, d, e, f).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C, D, E, F, G>
// {
//     public Cmd<A, B, C, D, E, F, G> WithAction(Func<A, B, C, D, E, F, G, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult),
// 					self.inputD.GetValue(parseResult),
// 					self.inputE.GetValue(parseResult),
// 					self.inputF.GetValue(parseResult),
// 					self.inputG.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C, D, E, F, G> WithAction(Func<A, B, C, D, E, F, G, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c, d, e, f, g) => action(a, b, c, d, e, f, g).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C, D, E, F, G, H>
// {
//     public Cmd<A, B, C, D, E, F, G, H> WithAction(Func<A, B, C, D, E, F, G, H, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult),
// 					self.inputD.GetValue(parseResult),
// 					self.inputE.GetValue(parseResult),
// 					self.inputF.GetValue(parseResult),
// 					self.inputG.GetValue(parseResult),
// 					self.inputH.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C, D, E, F, G, H> WithAction(Func<A, B, C, D, E, F, G, H, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c, d, e, f, g, h) => action(a, b, c, d, e, f, g, h).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C, D, E, F, G, H, I>
// {
//     public Cmd<A, B, C, D, E, F, G, H, I> WithAction(Func<A, B, C, D, E, F, G, H, I, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult),
// 					self.inputD.GetValue(parseResult),
// 					self.inputE.GetValue(parseResult),
// 					self.inputF.GetValue(parseResult),
// 					self.inputG.GetValue(parseResult),
// 					self.inputH.GetValue(parseResult),
// 					self.inputI.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C, D, E, F, G, H, I> WithAction(Func<A, B, C, D, E, F, G, H, I, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c, d, e, f, g, h, i) => action(a, b, c, d, e, f, g, h, i).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C, D, E, F, G, H, I, J>
// {
//     public Cmd<A, B, C, D, E, F, G, H, I, J> WithAction(Func<A, B, C, D, E, F, G, H, I, J, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult),
// 					self.inputD.GetValue(parseResult),
// 					self.inputE.GetValue(parseResult),
// 					self.inputF.GetValue(parseResult),
// 					self.inputG.GetValue(parseResult),
// 					self.inputH.GetValue(parseResult),
// 					self.inputI.GetValue(parseResult),
// 					self.inputJ.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C, D, E, F, G, H, I, J> WithAction(Func<A, B, C, D, E, F, G, H, I, J, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c, d, e, f, g, h, i, j) => action(a, b, c, d, e, f, g, h, i, j).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C, D, E, F, G, H, I, J, K>
// {
//     public Cmd<A, B, C, D, E, F, G, H, I, J, K> WithAction(Func<A, B, C, D, E, F, G, H, I, J, K, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult),
// 					self.inputD.GetValue(parseResult),
// 					self.inputE.GetValue(parseResult),
// 					self.inputF.GetValue(parseResult),
// 					self.inputG.GetValue(parseResult),
// 					self.inputH.GetValue(parseResult),
// 					self.inputI.GetValue(parseResult),
// 					self.inputJ.GetValue(parseResult),
// 					self.inputK.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C, D, E, F, G, H, I, J, K> WithAction(Func<A, B, C, D, E, F, G, H, I, J, K, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c, d, e, f, g, h, i, j, k) => action(a, b, c, d, e, f, g, h, i, j, k).Map(_ => 0));
//     }
// }
//
// public readonly partial record struct Cmd<A, B, C, D, E, F, G, H, I, J, K, L>
// {
//     public Cmd<A, B, C, D, E, F, G, H, I, J, K, L> WithAction(Func<A, B, C, D, E, F, G, H, I, J, K, L, IO<int>> action)
//     {
//         var self = this;
//         return self with
//         {
//             SetAction = command =>
//                 command.SetAction((parseResult, ct) => action(self.inputA.GetValue(parseResult),
// 					self.inputB.GetValue(parseResult),
// 					self.inputC.GetValue(parseResult),
// 					self.inputD.GetValue(parseResult),
// 					self.inputE.GetValue(parseResult),
// 					self.inputF.GetValue(parseResult),
// 					self.inputG.GetValue(parseResult),
// 					self.inputH.GetValue(parseResult),
// 					self.inputI.GetValue(parseResult),
// 					self.inputJ.GetValue(parseResult),
// 					self.inputK.GetValue(parseResult),
// 					self.inputL.GetValue(parseResult))
//             // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
//                         .RunAsync(EnvIO.New(token: ct))
//                         .AsTask())
//         };
//     }
//     
//     public Cmd<A, B, C, D, E, F, G, H, I, J, K, L> WithAction(Func<A, B, C, D, E, F, G, H, I, J, K, L, IO<Unit>> action)
//     {
//         var self = this;
//         return WithAction((a, b, c, d, e, f, g, h, i, j, k, l) => action(a, b, c, d, e, f, g, h, i, j, k, l).Map(_ => 0));
//     }
// }
