using System;

// [REF]
//  PG����: MessageBroker���g������(Pub/Sub�̌^�w��) https://takap-tech.com/entry/2023/01/23/234127

namespace UniRx {

    // [NOTE] 
    //  �f�t�H���g�� IMessagePublisher/IMessageReceiver �͌^�w�肪�ł��Ȃ��D�i���ǂ�Ȍ^�ł������Ă��܂��j
    //  ����Č^�w�肪�\�� Pub/Sub ��ǉ�����D


    /// <summary>
    /// �����I�Ɍ^���w�肵��Publisher�D
    /// </summary>
    public interface IMessagePublisher<T> {

        /// <summary>
        /// Send Message to all receiver.
        /// </summary>
        void Publish(T message);
    }

    /// <summary>
    /// �����I�Ɍ^���w�肵��Receiver�D
    /// </summary>
    public interface IMessageReceiver<T> {

        /// <summary>
        /// Subscribe typed message.
        /// </summary>
        IObservable<T> Receive();
    }

    public interface IMessageBroker<T> : IMessagePublisher<T>, IMessageReceiver<T> {

        public class DefaultImpl : IMessageBroker<T> {
            private readonly IMessageBroker _service;
            public DefaultImpl(IMessageBroker service) => _service = service;
            public void Publish(T message) => _service.Publish(message);
            public IObservable<T> Receive() => _service.Receive<T>();
        }
    }


    public static partial class MessageBrokerExtensions {

        public static IMessagePublisher<T> GetPublisher<T>(this IMessageBroker self) {
            return new IMessageBroker<T>.DefaultImpl(self);
        }

        public static IMessageReceiver<T> GetSubscriber<T>(this IMessageBroker self) {
            return new IMessageBroker<T>.DefaultImpl(self);
        }
    }

    // ����Subscribe�ł���悤�Ƀ��\�b�h��ǉ�����
    public static partial class IMessageReceiverExtensions {

        /// <summary>
        /// ���� Subscribe ����g�����\�b�h�D
        /// </summary>
        public static IDisposable Subscribe<T>(this IMessageReceiver self, Action<T> action) {
            return self.Receive<T>().Subscribe(action);
        }

        /// <summary>
        /// ���� Subscribe ����g�����\�b�h�D
        /// </summary>
        public static IDisposable Subscribe<T>(this IMessageReceiver<T> self, Action<T> action) {
            return self.Receive().Subscribe(action);
        }
    }
}
