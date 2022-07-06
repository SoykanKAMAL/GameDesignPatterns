using Unity.VisualScripting;

namespace ServiceLocator
{
    public class Locator
    {
        private static NullFxManager _nullFxManager;
        private static FxManager _fxManager;
        
        static Locator ()
        {
		    _nullFxManager = new NullFxManager();
            _fxManager = _nullFxManager;
        }
        
        public static FxManager GetFxManager () => _fxManager;
        
        public static void Provide(FxManager fxManager) => _fxManager = fxManager ?? _nullFxManager;
    }
}